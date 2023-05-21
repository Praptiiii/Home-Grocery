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
    public class ProductController : ControllerBase
    {

        //get applicationdbcontext by dependency injection and assign it to a local variable

        //private readonly ApplicationDbContext _db;

        private readonly IProduct _dbProduct;
        private readonly IMapper _mapper;
        public ProductController(IProduct dbProduct, IMapper mapper)
        {
            _dbProduct= dbProduct;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            IEnumerable<Product> productlist = await _dbProduct.GetAllAsync();
            return Ok(_mapper.Map<List<ProductDTO>>(productlist));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {
            if(id==0)
            {
                return BadRequest();
            }
            var pro = await _dbProduct.GetByIDAsync(x => x.ProductID == id);
            if(pro==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDTO>(pro));
        }

        [HttpPost()]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductDTO dto)
        {
            /*//first check if that product exist or not
            if(await _dbProduct.GetByIDAsync(u => u.ProductName.ToLower() == dto.ProductName.ToLower()) !=null)
            {
                ModelState.AddModelError("CustomError", "Product already exists");
                return BadRequest(ModelState);
            }
            if(dto == null) 
            {
                return BadRequest(dto);
            }
           /* if(dto.ProductID>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }*/
            
           Product model = _mapper.Map<Product>(dto);
            
            //manual map the model properties to dto
           /* Product model = new()
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
                Imageurl = dto.Imageurl,
            };*/
            
            
            await _dbProduct.CreateAsync(model);
            
            return Ok(model);
            //await _dbProduct.CreateAsync(model);

            //return CreatedAtRoute("GetProduct", new { id = model.ProductID }, model);

        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var prod = await _dbProduct.GetByIDAsync(x => x.ProductID == id);
            if(prod==null)
            {
                return NotFound();
            }
            
            await _dbProduct.RemoveAsync(prod);
            return NoContent();
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO dto)
        {
            if(dto==null || id!=dto.ProductID)
            {
                return BadRequest();
            }
            Product model = _mapper.Map<Product>(dto);
            
            /*//map model prop to dto
            Product model = new()
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
                Imageurl = dto.Imageurl,
            };*/
            

            await _dbProduct.UpdateAsync(model);
            return NoContent();
        }



    }
}
