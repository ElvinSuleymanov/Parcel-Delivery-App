using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class OrderRepository(ApplicationDbContext applicationDbContext) : IOrderRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext ;
    public async Task<ApiResponse<CreateOrderResponse>> Create(CreateOrderRequest request)
    {
        Order order= new () {Destination = request.Destination, UserId = request.UserId, AdminId = request.AdminId };
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        request.ProductId.ForEach(async id => {
            await _context.ProductOrders.AddAsync(new ProductOrder {OrderId = order.Id, ProductId = id });
        });
        return ApiResponse<CreateOrderResponse>.Success(new CreateOrderResponse{});
    }
    public async Task<ApiResponse<DeleteOrderResponse>> Delete(DeleteOrderRequest request)
    {
        var target = await _context.Orders.Where(o => o.Id == request.Id).FirstOrDefaultAsync();
        _context.Orders.Remove(target);
        return ApiResponse<DeleteOrderResponse>.Success(new DeleteOrderResponse{});
    }
    public async Task<ApiResponse<GetOrderResponse>> Get(GetOrderRequest request)
    {
            var Parcels = await _context.Orders.Where
            (x => 
            (request.OrderId == null || x.Id == request.OrderId)
            && 
            (request.CourierId == null || x.CourierId == request.CourierId)
            && 
            (request.UserId == null || x.UserId == request.UserId)
            &&
            (request.AdminId == null || x.AdminId == request.AdminId)
            )
            .Include(x => x.ProductOrders)
            .ThenInclude(x => x.Product)
            .Select(o => new GetOrderDto { Products = o.ProductOrders.Select(x => x.Product).ToList(),Id = o.Id, Destination = o.Destination, UserId = o.UserId, Status = o.Status, CourierId = (int)o.CourierId})
            // .SelectMany(o => o.ProductOrders, (o, po) => new GetOrderDto { Products = po.Product,Id = o.Id, Destination = o.Destination, UserId = o.UserId, Status = o.Status, CourierId = (int)o.CourierId})
            .ToListAsync();
            return ApiResponse<GetOrderResponse>.Success(new GetOrderResponse{Orders = Parcelsq});
    }
    public async Task<ApiResponse<UpdateOrderResponse>> Update(UpdateOrderRequest request)
    {
        var target = await _context.Orders.Where(x => x.Id == request.OrderId).FirstOrDefaultAsync();
        bool isTargetNull = target is null;
        if (isTargetNull) 
            return ApiResponse<UpdateOrderResponse>.NotFound();
        target.Status = request.OrderStatus;
        target.CourierId = request.CourierId;
        _context.Orders.Update(target);
        return ApiResponse<UpdateOrderResponse>.Success(new UpdateOrderResponse {});
    }
}
