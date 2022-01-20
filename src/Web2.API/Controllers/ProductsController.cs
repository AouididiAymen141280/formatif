using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Web2.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        static List<Product­> Products { get; set; }= new List<Product>
            {
                new Product { Id = 1, Nom="TV" },
                new Product { Id = 2, Nom="PS4"},
                new Product { Id = 3, Nom="sAMSUNH G30"}
            };
        static int prochainId = 4;

        // GET: api/<ProductsController>

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <response code="200">Produits retournés succés</response>
        /// <response code="404">Produits non trouvés</response>
        /// <returns>List de produits</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Products;
        }

        //// GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Product> Get(int id)
        //{
        //    var Product =  Products.FirstOrDefault(p => p.Id == id); ;

        //    if (Product == null)
        //        return NotFound();

        //    return Product;
        //}



        // POST api/<ProductsController>
        /// <summary>
        /// Ajouter un produit
        /// </summary>
        /// <param name="product">un produit décrit par un id et un nom</param>
        /// <response code="200">Produit ajouté avec succés</response>
        /// <response code="201">Produit ajouté et retourné dans la requête</response>
        /// <response code="204">Produit ajouté mais rien n'est retourné</response>
        /// <returns>Le produit crée</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(Product), 204)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(Product product)
        {
            product.Id = prochainId++;
            Products.Add(product);
            return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
        }

        //// PUT api/<ProductsController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, Product Product)
        //{
        //    if (id != Product.Id)
        //        return BadRequest();

        //    var ProductExistant = Get(id);
        //    if (ProductExistant is null)
        //        return NotFound();
        //    var index = Products.FindIndex(p => p.Id == Product.Id);
        //    if (index == -1)
        //         return NoContent();


        //    Products[index] = Product;
        //}

        // DELETE api/<ProductsController>/5

        /// <summary>
        /// Supprimer un produit
        /// </summary>
        /// <param name="id">L'identifiant du produit à suuprimer</param>
        /// <response code="204">Produit supprimé</response>
        /// <response code="404">Produit à supprimer non trouvé</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product),204)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            Products.Remove(product);

            return NoContent();
        }
    }
}

