namespace KFC_Base

type Size = 
    |Small
    |Medium
    |Big


module sizeString = 
    let SizeToString = function
        |Small -> "Маленький"
        |Medium -> "Средний"
        |Big -> "Большой"
    

    