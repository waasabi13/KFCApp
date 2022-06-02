namespace KFC_Base

open System.IO
open Newtonsoft.Json.Linq

type JsonDB(file: string)=
    let Items:(KFCItemsBase list)=
        let rootObj = JObject.Parse(File.ReadAllText(file))
        let burgers = rootObj.["BURGER"].ToObject<Burger list>()
        let chicken = rootObj.["FRIEDCHICKEN"].ToObject<FriedChicken list>()
        let snacks = rootObj.["SNACK"].ToObject<Snack list>()
        let drinks = rootObj.["DRINK"].ToObject<Drink list>()

        List.map (fun b -> upcast b) burgers @ List.map  (fun c -> upcast c) chicken @ List.map  (fun s -> upcast s) snacks @ List.map  (fun d -> upcast d) drinks
    
    member this.Menu() = 
        Items

    member this.GetAllBurgers() = 
        List.filter (fun (item: KFCItemsBase) -> item :? Burger) Items

    member this.GetAllChicken() = 
        List.filter (fun (item: KFCItemsBase) -> item :? FriedChicken) Items

    member this.GetAllSnacks() = 
        List.filter (fun (item: KFCItemsBase) -> item :? Snack) Items

    member this.GetAllDrinks() = 
        List.filter (fun (item: KFCItemsBase) -> item :? Drink) Items

    static member Sorted(items: (KFCItemsBase list), sortingFunction) =
        List.sortWith sortingFunction items

    member this.GetMostExpensive() = 
        List.maxBy(fun (item:KFCItemsBase) -> item.Price) (this.Menu())

    member this.GetBiggestBurger() = 
        let burgers = List.map(fun (item:KFCItemsBase)->item:?>Burger) (this.GetAllBurgers())
        List.maxBy(fun (item:Burger) -> item.Weight) burgers

    member this.GetMostCheapDrink() = 
        let drinks = List.map(fun (item:KFCItemsBase)->item:?>Drink) (this.GetAllDrinks())
        List.minBy(fun (item:Drink) -> item.Price) drinks

    member this.GetMostKcalSnack() = 
        let snacks = List.map(fun (item:KFCItemsBase)->item:?>Snack) (this.GetAllSnacks())
        List.maxBy(fun (item:Snack) -> item.Kcal) snacks

    //самый дешевый низкокалорийный бургер
    member this.GetCheapBurger() = 
        let burgers = List.map(fun (item:KFCItemsBase)->item:?>Burger) (this.GetAllBurgers())
        List.minBy(fun (item:Burger) -> item.Price) burgers
        