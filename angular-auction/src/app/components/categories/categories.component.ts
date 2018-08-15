import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/Category.model';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: 'categories.component.html',
  styleUrls: ['categories.component.css']
}) export class CategoriesComponent implements OnInit{

  categories: Category[] = [];
    
  constructor(private categoryService: CategoryService) {}

  ngOnInit() {
    this.categoryService.getCategories()
      .subscribe((data: any) => {
        for (var i = 0; i < data.length; i++) {
        this.categories[i] = data[i];
          for (var j = 0; j < this.categories[i].Name.split(" ").length; j++) {
            if (j == 0)
              this.categories[i].FirstWordOfName = this.categories[i].Name.split(" ")[j];
            else if (j > 0 && this.categories[i].OtherWordsOfName == null)
              this.categories[i].OtherWordsOfName = this.categories[i].Name.split(" ")[j] + " ";
            else
              this.categories[i].OtherWordsOfName += this.categories[i].Name.split(" ")[j] + " ";
          }
        }
      });
  }

  private getCategory(parentFirstWordOfName: string, parentOtherWordsOfName: string) {
    this.categoryService.doParent(parentFirstWordOfName, parentOtherWordsOfName);
  }
}
