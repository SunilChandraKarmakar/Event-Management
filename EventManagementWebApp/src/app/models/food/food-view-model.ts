import { DishTypeViewModel } from "../dishtype/dish-type-view-model";
import { FoodTypeViewModel } from "../foodtype/food-type-view-model";
import { MealTypeViewModel } from "../mealtype/meal-type-view-model";
import { UserViewModel } from "../user/user-view-model";

export class FoodViewModel {
    id: number;
    title: string;
    userId: string;
    foodTypeId: number;
    mealTypeId: number;
    dishTypeId: number;
    isSouthIndiaThali: boolean;
    isNorthIndianThali: boolean;
    isPunjabThali: boolean;
    isMaharashtrianThali: boolean;
    foodAmount: number;

    user: UserViewModel;
    foodType: FoodTypeViewModel;
    mealType: MealTypeViewModel;
    dishType: DishTypeViewModel;
}