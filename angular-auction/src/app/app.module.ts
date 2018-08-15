import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { UserService } from './services/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './components/header/header.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { CategoryService } from './services/category.service';
import { LotsComponent } from './components/Lots/Lots.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';

const appRoutes: Routes = [
  { path: '', component: LotsComponent },
  { path: 'category/:id', component: LotsComponent },
  { path: 'login', component: SignInComponent },
  { path: 'registration', component: SignUpComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LotsComponent,
    LeftMenuComponent,
    CategoriesComponent,
    SignInComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UserService, CategoryService, AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
