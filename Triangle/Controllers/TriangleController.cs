using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TriangleController : Controller
{
    public IActionResult Index()
    {
        return View("Shared", "Index");
    }

    [HttpPost]
    public IActionResult CalculateType(TriangleModel model)
    {
        double[] sides = new double[] { model.SideA, model.SideB, model.SideC };

        if (sides.All(s => s <= 0))
        {
            ModelState.AddModelError("", "Invalid triangle sides.");
            return View("Index");
        }

        if (sides.Distinct().Count() == 1)
        {
            model.TriangleType = "Equilateral";
        }
        else if (sides.Distinct().Count() == 2)
        {
            model.TriangleType = "Isosceles";
        }
        else
        {
            model.TriangleType = "Scalene";
        }

        return View("Result", model);
    }
}
