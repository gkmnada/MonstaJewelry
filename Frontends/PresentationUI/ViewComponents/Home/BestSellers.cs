﻿using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Bestsellers : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}