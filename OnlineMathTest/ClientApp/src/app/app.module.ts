
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
import { SharedService } from './Services/sharedService';
import { AuthenticationService } from './Services/AuthenticationService';
import { JwtInterceptor } from './Interceptors/JwtInterceptor';

import { AdminAuthGuardService } from './Services/AdminAuthGuardService';
import { QuestiontypeComponent } from './Components/questiontype/questiontype.component';
import { UserComponent } from './Components/user/user.component';
import { AdminModule } from './Modules/admin.module';
import { StatisticModule } from './Modules/statistic.module';
import { MCQModule } from './Modules/mcq.module';
import { DashBoardModule } from './Modules/dashboard.module';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginFormComponent,
    RegisterFormComponent,
    QuestiontypeComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AdminModule,
    MCQModule,
    StatisticModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'mcq', loadChildren: './Modules/mcq.module#MCQModule' },
      { path: 'questiontype', component: QuestiontypeComponent },
      { path: 'profile/:id', component: UserComponent },
      { path: 'statistic', loadChildren: './Modules/statistic.module#StatisticModule' },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: 'dashboard', loadChildren: './Modules/dashboard.module#DashBoardModule', canActivate: [AdminAuthGuardService] },
      { path: 'adminpage', loadChildren: './Modules/admin.module#AdminModule', canActivate: [AdminAuthGuardService] },
      { path: '**', component: HomeComponent },
    ], { useHash: true }),
    DashBoardModule
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
