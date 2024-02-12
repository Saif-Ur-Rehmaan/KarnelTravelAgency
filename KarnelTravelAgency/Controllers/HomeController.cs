using System.Diagnostics;
using Azure;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Models;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KarnelTravelAgency.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        
        [Route("/")]        
        [Route("/Home")]        
        public IActionResult Index2()
        {
            return View();
        }
        [Route("/Home2")]        
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Error404")]        
        public IActionResult ErrorPage()
        {
            return View();
        }
        
        [Route("/Gallery")]        
        public IActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        [Route("/Newsletter")]
        public IActionResult AddNewsLetter()
        {
            try
            {
                string mail = Request.Form["Email"];

                new NewslettersSubscriptionRepo(context).Add(new NewslettersSubscription()
                {
                    Email = mail
                }) ;
                TempData["NewsLetterSubmittionState"] = true;

            }
            catch (Exception ex)
            {
                TempData["NewsLetterSubmittionState"] = true;
                TempData["ErrorMsg"] = ex.Message;

            }
            return Redirect("/");

        }


        [HttpPost]
        [Route("/Search")]
        public IActionResult Search()
        {
            var Action = Request.Form["Action"];
            var Location = Request.Form["Location"]; 
            var MaximumPrice = Request.Form["MaximumPrice"];

            // Construct query string
            var queryString = $"?Location={Location}&MaximumPrice={MaximumPrice}";

            switch (Action)
            {
                case "Hotel":
                    return Redirect($"/SearchHotel{queryString}");
                case "Resort":
                    return Redirect($"/SearchResort{queryString}");
                case "Flight":
                    return Redirect($"/SearchFlight{queryString}");
                     
                case "Restaurant":
                    return Redirect($"/SearchRestaurant{queryString}");
                default:
                    TempData["NoDataAvalible"] = "Select Action First";
                    return Redirect("/");
            }          
             
        }


        [HttpPost]
        [Route("LookingFor")]
        public IActionResult WhatAreYouLookingFor()
        {
            var Query = Request.Form["Query"].ToString().Split(" ");
            bool found = false;

            foreach (var word in Query)
            {
                if (word.ToLower() == "hotel")
                {
                    return Redirect("/Hotels");
                }
                else if (word.ToLower() == "resort")
                {
                    return Redirect("/Resorts");
                }
                else if (word.ToLower() == "flight")
                {
                    return Redirect("/Flights");
                }
                else if (word.ToLower() == "restaurant")
                {
                    return Redirect("/Restaurants");
                }
            }

            // If none of the keywords were found in any of the words, set TempData and redirect
            TempData["NoDataAvalible"] = "No Action Available For the Search";
            return Redirect("/");


        }
    }
}
