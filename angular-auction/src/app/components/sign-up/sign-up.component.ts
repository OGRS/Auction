import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: 'sign-up.component.html',
  styleUrls: ['sign-up.component.css']
}) export class SignUpComponent implements OnInit{
  isRegistrationSuccess: boolean = false;
  isRegistrationError: boolean = false;
  Message: string;
  user: User;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      UserName: '',
      Password: '',
      ConfirmPassword: '',
      Email: ''
    }
  }

  OnSubmit(form: NgForm) {
    this.userService.registerUser(form.value)
      .subscribe((data: any) => {
        if (data.Succeeded == true) {
          this.resetForm(form);
          this.Message = "Регистрация прошла успешно";
          this.isRegistrationSuccess = true;
          this.isRegistrationError = false;
        }
      },
      (err: HttpErrorResponse) => {
        this.Message = err.error.ModelState[""];
        this.isRegistrationError = true;
        this.isRegistrationSuccess = false;
      });
  }
}
