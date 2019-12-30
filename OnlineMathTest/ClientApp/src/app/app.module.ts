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
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { SharedService } from './Services/sharedService';
import { MathJaxModule } from './Modules/math-jax.module';

import { AuthGuardService } from './Services/AuthGuardService';
import { AuthenticationService } from './Services/AuthenticationService';
import { JwtInterceptor } from './Interceptors/JwtInterceptor';
import { ExamComponent } from './Components/exam/exam.component';
import { DasboardComponent } from './Components/dasboard/dasboard.component';
import { AdminAuthGuardService } from './Services/AdminAuthGuardService';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ListMcqComponent,
    UserComponent,
    LoginFormComponent,
    RegisterFormComponent,
    McqDetailComponent,
    ExamComponent,
    DasboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MathJaxModule.forRoot({
      version: '2.7.5',
      config: 'TeX-AMS_HTML',
      hostname: 'cdnjs.cloudflare.com'
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'listmcq', component: ListMcqComponent },
      { path: 'mcqdetail/:id', component: McqDetailComponent },
      { path: 'user', component: UserComponent },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: 'exam/id', component: ExamComponent, canActivate: [AuthGuardService] },
      { path: 'dashboard', component: DasboardComponent, canActivate: [AdminAuthGuardService] },
      { path: '**', component: HomeComponent },
    ])
  ],
  providers: [
    SharedService,
    AuthGuardService,
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
