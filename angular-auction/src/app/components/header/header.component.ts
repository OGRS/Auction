import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['header.component.css']
}) export class HeaderComponent implements OnInit {

  isLogin: boolean;
  userName: string;

  ngOnInit() {
    this.userService.isLogin.subscribe(predicate => {
      if (predicate == true) {
        this.SetData();
      }
    });

    if (sessionStorage.getItem('userToken') != null) {
      this.SetData();
    }
    else
      this.isLogin = false;
  }

  private SetData() {
    this.userName = sessionStorage.getItem('userName');
    this.isLogin = true;
  }

  constructor(private userService: UserService) {}

  Exit() {
    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('userName');
  }
}
