﻿using DataAccess.Entities;
using ServiceLayer.Services;
using System.Linq;
using System.Web.Mvc;
using TaskManagerMVC.Filters;
using TaskManagerMVC.Models;
using TaskManagerMVC.ViewModels;

namespace TaskManagerMVC.Controllers
{
    [Authenticate]
    public abstract class BaseController<T, I, F, D, C> : Controller
        where T : BaseEntity, new()
        where I : BaseIndexVM<T, F>, new()
        where F : BaseFilterVM<T>, new()
        where D : BaseDetailsVM<T>, new()
        where C : BaseCreateEditVM<T>, new()
    {
        public abstract BaseService<T> GetService();

        public abstract I PopulateIndexModel(I model);

        public abstract D PopulateDetailsModel(D model);

        public abstract C PopulateCreateEditModel(C model); // GET

        public abstract T PopulateEntity(C model, T entity); // POST

        // Index
        public ActionResult Index()
        {
            I model = new I();
            PopulateIndexModel(model);

            // Pagination
            model.Pager = new Pager(model.Items.Count, model.Pager == null ? 1 : model.Pager.CurrentPage, "Pager.", "Index", typeof(T).Name.ToString(), model.Pager == null ? 3 : model.Pager.PageSize);
            model.Items = model.Items.Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList();
            model.Filter.ParentPager = model.Pager;

            return View(model);
        }

        // Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            D model = new D()
            {
                ID = id.Value
            };

            PopulateDetailsModel(model);

            return View(model);
        }

        // CreateEdit GET
        [HttpGet]
        public ActionResult CreateEdit(int? id)
        {
            C model = new C();

            if (id > 0) // Edit
            {
                model.ID = id.Value;
            }

            PopulateCreateEditModel(model);

            return View(model);
        }

        // CreateEdit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(C model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            BaseService<T> entityService = GetService();
            T entity = new T();

            entity = PopulateEntity(model, entity);

            entityService.Save(entity);

            return RedirectToAction("Index");
        }

        // Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            BaseService<T> entityService = GetService();

            T entity = entityService.GetByID(id.Value);

            if (entity == null)
            {
                return HttpNotFound();
            }

            entityService.Delete(entity);

            return RedirectToAction("Index");
        }
    }
}