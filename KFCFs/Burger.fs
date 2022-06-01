namespace KFC_Base

type Burger(name: string, compound: string, kcal: double,proteins: double, fats: double, carbohydrates: double, price:double, pictureUrl: string, weight:double,spicy:bool ) = 
    inherit KFCItemsBase(name, compound, kcal,proteins, fats, carbohydrates, price, pictureUrl, weight)
    member this.Spicy = spicy
