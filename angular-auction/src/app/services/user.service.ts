import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { User } from 'src/app/models/User.model';


@Injectable()
export class UserService {

  isLogin: EventEmitter<boolean> = new EventEmitter();

  readonly baseUrl = 'http://localhost:10056/';
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      ConfirmPassword: user.ConfirmPassword,
      Email: user.Email
    }
 
    const reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.post(this.baseUrl + 'api/Account/Register', body, { headers: reqHeader });
  }

  userAuthentication(Email, password) {
    var data = "grant_type=password" + "&username=" + Email + "&password=" + password;
    
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded', 'No-Auth': 'True' });
    return this.http.post(this.baseUrl + 'Token', data, { headers: reqHeader });
  }

  doLogin() {
    this.isLogin.emit(true);
  }
}
