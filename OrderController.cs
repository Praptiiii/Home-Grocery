using AutoMapper;
using HomeGrocery.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeGrocery.BLL.DTO;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using HomeGrocery.DAL.Models;
using HomeGrocery.DAL.Repository.Interface;

namespace HomeGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _dbOrder;
        private readonly IMapper _mapper;
       // private readonly IProduct _dbProduct;
       
        public OrderController(IOrder dbOrder, IMapper mapper) //IProduct dbProduct)
        {
            _dbOrder = dbOrder;
            _mapper = mapper;
            //_dbProduct = dbProduct;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateOrder([FromBody] OrderDTO dto)
        {
            Order model = _mapper.Map<Order>(dto);
            await _dbOrder.CreateAsync(model);
            /*try
            {
               
                if (await _dbOrder.GetByIDAsync(u => u.OrderID == dto.OrderID)!=null) 
                {
                    ModelState.AddModelError("Custom Error", " Order Id already exists");
                    return BadRequest(ModelState);
                }

                if(await _dbProduct.GetByIDAsync(u => u.ProductID == dto.ProductID) == null)
                {
                    ModelState.AddModelError("Custome error", " Product ID is invalid");
                    return BadRequest(ModelState);  
                }

            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Exception Caught",ex);

            }*/
            
            
           

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Get()
        {
            IEnumerable<Order> orderlist = await _dbOrder.GetAllAsync();
            return Ok(_mapper.Map<List<UserDTO>>(orderlist));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var ord = await _dbOrder.GetByIDAsync(x => x.OrderID == id);
            if (ord == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDTO>(ord));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prod = await _dbOrder.GetByIDAsync(x => x.OrderID == id);
            if (prod == null)
            {
                return NotFound();
            }

            await _dbOrder.RemoveAsync(prod);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO dto)
        {
            if (dto == null || id != dto.OrderID)
            {
                return BadRequest();
            }
            Order model = _mapper.Map<Order>(dto);

            await _dbOrder.UpdateAsync(model);
            return NoContent();


        }
    }
}

