namespace KFC_Base
[<AbstractClass>]

type KFCItemsBase(name: string, compound: string, kcal: double,proteins: double, fats: double, carbohydrates: double, price:double, pictureUrl: string, weight:double) =
    member this.Name = name
    member this.Compound = compound
    member this.Kcal = kcal
    member this.Proteins = proteins
    member this.Fats = fats
    member this.Carbohydrates = carbohydrates
    member this.Price = price
    member this.PictureURL = pictureUrl
    member this.Weight = weight

