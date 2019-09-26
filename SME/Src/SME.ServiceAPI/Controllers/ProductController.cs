using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Business.Manager.Product;

namespace SME.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Varaibles

        private IProductManager _prdManager;
        private ILogger<ProductController> _logger;

        #endregion

        #region Controller

        public ProductController(IProductManager prdManager, ILogger<ProductController> logger)
        {
            _prdManager = prdManager;
            _logger = logger;
        }

        #endregion

        #region Endpoints

        #region Product
        [HttpGet("products")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProducts()
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");

            var objPrd = await _prdManager.GetProducts();
            if (objPrd != null)
                return Ok(objPrd);

            return NotFound("Products not found");
        }

        [HttpGet("product/{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById([FromRoute] string Id)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var objPrd = await _prdManager.GetProductById(Id);
            if (objPrd != null)
                return Ok(objPrd);

            return NotFound("Product not found");
        }
        [HttpGet("product/{Name}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByName([FromRoute] string Name)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var objPrd = await _prdManager.GetProductByName(Name);
            if (objPrd != null)
                return Ok(objPrd);

            return NotFound("Product not found");
        }

        [HttpPost("create")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blPrd = await _prdManager.CreateProduct(objInput);
            if (blPrd)
                return Ok(blPrd);
            else

                return BadRequest("Product not created");
        }

        [HttpPut("update")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel objInput)
        {
            //var IsValidClaim = HttpContext.ValidatePermission("2");
            //if (!IsValidClaim)
            //    return Unauthorized("you don't have permission");


            var blPrd = await _prdManager.UpdateProduct(objInput);
            if (blPrd)
                return Ok(blPrd);
            else

                return BadRequest("Product not updated");
        }


        #endregion

        #endregion
    }
}