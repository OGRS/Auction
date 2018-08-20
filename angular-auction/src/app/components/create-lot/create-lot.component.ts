import { Component} from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../models/Category.model';

@Component({
  selector: 'app-create-lot',
  templateUrl: 'create-lot.component.html',
  styleUrls: ['create-lot.component.css']
}) export class CreateLotComponent {

  categories: Category[][] = [];
  isChildsExist: boolean[] = [];
  selectedCategory: Category;
  isCategorySelected: boolean = false;
  activeCategory: Category[] = [];

  getCategories() {
    this.categoryService.getCategories().subscribe((data: any) => {
      this.categories[0] = data;
      this.isCategorySelected = false;
    });
  }

  getCategoryParent(category: Category, card: number) {
    this.categoryService.getCategoriesByParentId(category.Id).subscribe((data: any) => {
      if (card == 1) {
        this.categories[1] = data;
        this.isChildsExist[0] = true;
        this.isChildsExist[1] = false;
        this.selectedCategory = null;
        this.activeCategory[0] = category;
      }
      else if (card == 2) {
        if (data == 0) {
          this.isChildsExist[1] = false;
          this.selectedCategory = category;
        }
        else {
          this.categories[2] = data;
          this.isChildsExist[1] = true;
        }
        this.activeCategory[1] = category;
      }
      else {
        this.activeCategory[2] = category;
        this.selectedCategory = category;
      }
    });
  }

  changePredicate(predicate: boolean) {
    this.isCategorySelected = predicate;
    document.getElementById("closeModal").click();
  }

  constructor(private categoryService: CategoryService) { }
}
