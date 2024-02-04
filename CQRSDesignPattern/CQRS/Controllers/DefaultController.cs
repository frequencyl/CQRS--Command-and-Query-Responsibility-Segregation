using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Commands;
using CQRS.CQRSPattern.Handlers;
using CQRS.CQRSPattern.Queries;
using CQRS.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CQRS.Controllers
{
    public class DefaultController:Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetProductUpdateByIDQueryHandler _getProductUpdateByIDQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler,
        GetProductByIDQueryHandler getProductByIDQueryHandler, DeleteProductCommandHandler deleteProductCommandHandler,
        GetProductUpdateByIDQueryHandler getProductUpdateByIDQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getProductUpdateByIDQueryHandler = getProductUpdateByIDQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index(){
            var values= _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct(){
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command){
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        
        public IActionResult GetProduct(int id){
            var values= _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }
     
        public IActionResult DeleteProduct(int id){
            _deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id){
            var values=_getProductUpdateByIDQueryHandler.Handle(new GetProductUpdateByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand updateProductCommand){
            _updateProductCommandHandler.Handle(updateProductCommand);
            return RedirectToAction("Index");
        }
    }
}