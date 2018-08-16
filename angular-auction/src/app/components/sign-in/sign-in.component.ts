import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: 'sign-in.component.html',
  styleUrls: ['sign-in.component.css']
}) export class SignInComponent implements OnInit {

  Error: string;
  isLoginError: boolean = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  OnSubmit(Email, password) {
    this.userService.userAuthentication(Email, password).subscribe((data: any) => {
      sessionStorage.setItem('userToken', data.access_token);
      sessionStorage.setItem('userName', data.Name);
      this.userService.doLogin();
      this.router.navigate(['/']);
    },
      (err: HttpErrorResponse) => {
        this.isLoginError = true;
        this.Error = err.error.error_description;
      });
  }
}
