namespace KFC_Base

type Burger(name: string, compound: string, kcal: double,proteins: double, fats: double, carbohydrates: double, price:double, pictureUrl: string, weight:double,size: Size ) = 
    inherit KFCItemsBase(name, compound, kcal,proteins, fats, carbohydrates, price, pictureUrl, weight)
    member this.Size = size
