using SPAajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPAajax.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Returns the partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult ListOfMembers()
        {
            using (MyContext db = new MyContext())
            {
                var obj = db.Members.ToList();
                return PartialView("ListOfMembersPartialView", obj);
            }
        }

        /// <summary>
        /// To save the new or edited member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public JsonResult Save(Member member)
        {
            using (MyContext db = new MyContext())
            {
                try
                {
                    if (member.ID != 0)
                    {
                        //check validations first on edit and retun exception if invalid(not performed here.)
                        //get existing memeber 
                        //assign the edited value
                        //save

                        var existingMember = db.Members.Find(member.ID);
                        existingMember.Name = member.Name;
                        existingMember.age = member.age;
                        db.SaveChanges();
                        return Json("member edited");
                    }

                    //else add new member
                    db.Members.Add(member);
                    db.SaveChanges();
                    return Json("new member added");
                }
                catch
                {
                    return Json("Error");
                }
            }
        }

        /// <summary>
        /// Deletes the Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {
            using (MyContext db = new MyContext())
            {
                try
                {
                    var obj = db.Members.Find(id);
                    db.Members.Remove(obj);
                    db.SaveChanges();
                }
                catch
                {
                    return Json("Error");
                }
            }
            return Json("deleted");
        }

    }
}