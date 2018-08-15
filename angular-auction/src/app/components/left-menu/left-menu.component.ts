import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/Category.model';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-left-menu',
  templateUrl: 'left-menu.component.html',
  styleUrls: ['left-menu.component.css']
}) export class LeftMenuComponent implements OnInit {

  categories: Category[] = [];
  isParentExist: boolean;
  isParent: boolean = false;
  parentFirstWordOfName: string;
  parentOtherWordsOfName: string;

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params['id'] == null) {
        this.isParentExist = false;
      }
      else {
        this.parentFirstWordOfName = sessionStorage.getItem('parentFirstWordOfName');
        this.parentOtherWordsOfName = sessionStorage.getItem('parentOtherWordsOfName');

        this.categoryService.getCategoriesByParentId(params['id'])
          .subscribe((data: any) => {
            if (data == 0)
              this.isParent = true;
            else {
              this.categories = data;
              this.isParentExist = true;
              this.isParent = false;
            }  
          });
      }
    }); 
  }

  constructor(private categoryService: CategoryService, private activatedRoute: ActivatedRoute) { }

  private getCategory(parentName: string) {
    this.categoryService.doParent(parentName, null);
  }
}
