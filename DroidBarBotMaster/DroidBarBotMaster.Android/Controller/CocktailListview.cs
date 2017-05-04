using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DroidBarBotMaster.Droid.Class.Service;
using DroidBarBotMaster.Droid.Class.Helper;
using DroidBarBotMaster.Droid.Class.Model;
using DroidBarBotMaster.Droid.Controller;

namespace DroidBarBotMaster.Droid
{
    [Activity(Label = "CocktailListview")]
    public class CocktailListview : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CocktailListview);

            
        }



        protected override void OnStart()
        {
            base.OnStart();

            List<DrinkMultiple> available = new List<DrinkMultiple>();

            List<String> drinkNames = new List<string>() { "lime", "vodka", "tequila" };

            //List<DrinkMultiple> availableDrinks = CocktailDBService.getAllDrinks(drinkNames);
            List<DrinkMultiple> availableDrinks = CocktailDBService.getAllDrinksShallow(drinkNames);

            //List<DrinkMultiple> availableDrinksMixFiltered = CocktailDBService.MixableDrinksFiltered(availableDrinks, drinkNames, drinkNames.Count);

            //FindViewById<Button>(Resource.Id.cocktailListView).AddChildrenForAccessibility(drinkNames);

            ListView lt = FindViewById<ListView>(Resource.Id.cocktailListView);


            //ArrayAdapter<Drink> adapter = new ArrayAdapter<Drink>(this, Resource.Layout.XMLFile1, availableDrinks[0].Drinks);

            List<Drink> allDrinks = new List<Drink>();

            foreach (var item in availableDrinks)
            {
                allDrinks.AddRange(item.Drinks);
            }

            listAdapterDrink adapter = new listAdapterDrink(this, allDrinks);
            lt.Adapter = adapter;

            lt.Clickable = true;
            lt.SetOnClickListener(new ListItemClick());


            #region How to Connect
            // TODO: Dev deactivate

            //foreach (var item in TransporterClass.listContainer)
            //{
            //    DrinkMultiple tempDrinks = CocktailDBService.HttpGet(item.Name, HttpGetRequests.CocktailByIngridient);

            //    if (tempDrinks != null)
            //    {
            //        available.Add(tempDrinks);
            //    }
            //}

            //Console.WriteLine(available); 
            #endregion


        }

    }
}