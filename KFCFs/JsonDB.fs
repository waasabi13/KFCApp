namespace KFC_Base

open System.IO
open Newtonsoft.Json.Linq

type JsonDB(file: string)=
    let Items:(KFCItemsBase list)=
        let rootObj = JObject.Parse(File.ReadAllText(file))
        let burgers = rootObj.["BURGERS"].ToObject<Burger list>()
        let chicken = rootObj.["Fried Chicken"].ToObject<FriedChicken list>()
        let snacks = rootObj.["Snacks"].ToObject<Snack list>()
        let drinks = rootObj.["Drinks"].ToObject<Drink list>()

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
