import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './Components/app/app.component';
import { HomeComponent } from './Components/home/home.component';
import { NavMenuComponent } from './Components/nav-menu/nav-menu.component';
import { ListMcqComponent } from './Components/list-mcq/list-mcq.component';
import { McqDetailComponent } from './Components/list-mcq/mcq-detail.component';
import { UserComponent } from './Components/user/user.component';
import { LoginFormComponent } from './Components/login-form/login-form.component';
import { RegisterFormComponent } from './Components/register-form/register-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ListMcqComponent,
    UserComponent,
    LoginFormComponent,
    RegisterFormComponent,
    McqDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'MCQ', component: ListMcqComponent },
      { path: 'MCQdetail/:id', component: McqDetailComponent },
      { path: 'User', component: UserComponent },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: '**', component: HomeComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
