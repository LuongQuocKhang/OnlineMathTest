/// <reference path="services/math-jax.service.ts" />
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './Components/app/app.component';
import { HomeComponent } from './Components/home/home.component';
import { NavMenuComponent } from './Components/nav-menu/nav-menu.component';

import { LoginFormComponent } from './Components/login-form/login-form.component';
import { RegisterFormComponent } from './Components/register-form/register-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { MCQModule } from './Modules/mcq.module';
import { SharedService } from './Services/sharedService';

import { AuthenticationService } from './Services/AuthenticationService';
import { JwtInterceptor } from './Interceptors/JwtInterceptor';
import { ExamComponent } from './Components/exam/exam.component';
import { DasboardComponent } from './Components/dasboard/dasboard.component';
import { AdminAuthGuardService } from './Services/AdminAuthGuardService';
import { QuestiontypeComponent } from './Components/questiontype/questiontype.component';
import { UserComponent } from './Components/user/user.component';
import { AdminModule } from './Modules/admin.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginFormComponent,
    RegisterFormComponent,
    ExamComponent,
    DasboardComponent,
    QuestiontypeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MCQModule,
    AdminModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'mcq', loadChildren: './Modules/mcq.module#MCQModule' },
      { path: 'questiontype', component: QuestiontypeComponent },
      { path: 'user', component: UserComponent },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: 'dashboard', component: DasboardComponent, canActivate: [AdminAuthGuardService] },
      { path: 'admin', loadChildren: './Modules/admin.module#AdminModule', canActivate: [AdminAuthGuardService] },
      { path: '**', component: HomeComponent },
    ])
  ],
  providers: [
    SharedService,
    AdminAuthGuardService,
    AuthenticationService,

    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
