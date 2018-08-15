import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';


@Injectable()
export class CategoryService {

  isParent: EventEmitter<boolean> = new EventEmitter();

  readonly baseUrl = 'http://localhost:10056/';
  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get(this.baseUrl + 'api/Category');
  }

  getCategoriesByParentId(id: number) {
    return this.http.get(this.baseUrl + 'api/Category/' + id);
  }

  doParent(parentFirstWordOfName: string, parentOtherWordsOfName: string) {
    sessionStorage.setItem('parentFirstWordOfName', parentFirstWordOfName);
    parentOtherWordsOfName ? sessionStorage.setItem('parentOtherWordsOfName', parentOtherWordsOfName)
      : sessionStorage.setItem('parentOtherWordsOfName', "");
    this.isParent.emit(true);
  }
}
