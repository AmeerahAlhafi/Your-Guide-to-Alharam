using alharamApp.Models;
using alharamApp.myData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alharamApp;

namespace alharamApp.Controllers
{
    public class alharamController : Controller
    {
        alharamDBEntities dbAccess = new alharamDBEntities();

        alharamDBFacilities dbAccessFacilitie = new alharamDBFacilities();

        public ViewResult Index()
        {
            return View("Index");
        }

       
        public ViewResult about()
        {
            return View("about");
        }


        public ViewResult aboutVision()
        {
            return View("aboutVision");
        }

      
        [Authorize]
        public ActionResult contact()
        {
            return View("contact");
        }


        //Display all places

        public ActionResult showAllBarbershop()
        {
            List<facilitie> barbershops = new List<facilitie>();

            alharamDAO barbershopDAO = new alharamDAO();

            barbershops = barbershopDAO.fetchAllBarbershops();

            return View("showAllBarbershop", barbershops);

        }
   

        public ActionResult showAllHotel()
        {
            List<facilitie> hotels = new List<facilitie>();

            alharamDAO hotelDAO = new alharamDAO();

            hotels = hotelDAO.fetchAllHotels();

            return View("showAllHotel", hotels);

        }


        public ActionResult showAllRestaurant()
        {
            List<facilitie> restaurants = new List<facilitie>();

            alharamDAO restaurantDAO = new alharamDAO();

            restaurants = restaurantDAO.fetchAllRestaurants();

            return View("showAllRestaurant", restaurants);

        }

        //Display place depend on user search

           public ViewResult emptyRestaurant()
           {

            return View("emptyRestaurant");

           }

         public ViewResult emptyHotel()
          {

            return View("emptyHotel");

         }

        public ViewResult emptyBarbershop()
        {

            return View("emptyBarbershop");

        }

        [HttpPost]
        public ActionResult searchSomeBarbershop(string searchPlace)
        {
            List<facilitie> someBarbershops = new List<facilitie>();

            alharamDAO barbershopDAO = new alharamDAO();

            //to save textbox content in varibale "will use it to make a query"
            string txtSearch = (Request["txtBoxSearch"]);

            searchPlace = txtSearch;

           someBarbershops = barbershopDAO.searchBarbershops(searchPlace);

            if (someBarbershops.Count == 0)
            {
                return View("emptyBarbershop");
            }

            else
            {
                return View("showAllBarbershop", someBarbershops);
            }

        }

        [HttpPost]
        public ActionResult searchSomeHotel(string searchPlace)
        {
            List<facilitie> someHotels = new List<facilitie>();

            alharamDAO hotelDAO = new alharamDAO();
      
            //to save textbox content in varibale "will use it to make a query"
            string txtSearch = (Request["txtBoxSearch"]);

            searchPlace = txtSearch;

            someHotels = hotelDAO.searchHotels(searchPlace);

            if (someHotels.Count == 0)
            {
                return View("emptyHotel");
            }
            else
            {
                return View("showAllHotel", someHotels);
        }

    }


        [HttpPost]
        public ActionResult searchSomeRestaurant(string searchPlace)
        {
            List<facilitie> someRestaurants = new List<facilitie>();

            alharamDAO restaurantDAO = new alharamDAO();

            //to save textbox content in varibale "will use it to make a query"
            string txtSearch = (Request["txtBoxSearch"]);

            searchPlace = txtSearch;

            someRestaurants = restaurantDAO.searchRestaurants(searchPlace);

            if (someRestaurants.Count == 0)
            {
                return View("emptyRestaurant");
            }

            else
            {
                return View("showAllRestaurant", someRestaurants);
            }

        }

        [HttpPost]
        public ViewResult contactMessage(string name)
        {
            TempData["Message"] = "Dear " + name +" , thank you for contacting us, we always welcome your inquiries and comments";
            return View("contactMessage");
        }



        }//class end 
    }//name space end