import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';

import { RouterModule } from '@angular/router';
import { McqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.component';
import { McqquestionComponent } from '../Components/admin/mcqquestion/mcqquestion.component';
import { UserComponent } from '../Components/user/user.component';

import { AdminAuthGuardService } from '../Services/AdminAuthGuardService';
import { AddMcqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.add.component';
import { EditMcqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.edit.component';

@NgModule({
  declarations: [
    McqManagementComponent,
    AddMcqManagementComponent,
    EditMcqManagementComponent,

    McqquestionComponent,

    UserComponent
  ],
  imports: [
    ModuleShared,
    RouterModule.forRoot([
      { path: 'mcqmanagement', component: McqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'mcqmanagement/add', component: AddMcqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'mcqmanagement/edit/:id', component: EditMcqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'mcqquestion', component: McqquestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'mcqquestion/add', component: McqquestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'mcqquestion/edit/:id', component: McqquestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'user', component: UserComponent, canActivate: [AdminAuthGuardService] },
    ]),
  ],
  providers: [
    AdminAuthGuardService
  ],
})
export class AdminModule {

}
