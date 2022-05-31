namespace KFC_Base

type Drink(name: string, compound: string, kcal: double,proteins: double, fats: double, carbohydrates: double, price:double, pictureUrl: string, weight:double,size: Size, hot:bool ) = 
    inherit KFCItemsBase(name, compound, kcal,proteins, fats, carbohydrates, price, pictureUrl, weight)
    member this.Hot = hot
    member this.Size = size