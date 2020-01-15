import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';

import { RouterModule } from '@angular/router';
import { McqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.component';
import { McqQuestionComponent } from '../Components/admin/mcqquestion/mcqquestion.component';
import { UserManagementComponent } from '../Components/admin/user/usermanagement.component';

import { AdminAuthGuardService } from '../Services/AdminAuthGuardService';
import { AddMcqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.add.component';
import { EditMcqManagementComponent } from '../Components/admin/mcqmanagement/mcqmanagement.edit.component';
import { AddMcqQuestionComponent } from '../Components/admin/mcqquestion/mcqquestion.add.component';
import { EditMcqQuestionComponent } from '../Components/admin/mcqquestion/mcqquestion.edit.component';
import { EditUserManagementComponent } from '../Components/admin/user/usermanagement.edit.component';

@NgModule({
  declarations: [
    McqManagementComponent,
    AddMcqManagementComponent,
    EditMcqManagementComponent,
    McqQuestionComponent,
    AddMcqQuestionComponent,
    EditMcqQuestionComponent,
    UserManagementComponent,
    EditUserManagementComponent
  ],
  imports: [
    ModuleShared,
    RouterModule.forChild([
      { path: 'adminpage/mcq', component: McqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/mcq/add', component: AddMcqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/mcq/edit/:id', component: EditMcqManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/mcqquestion', component: McqQuestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/mcqquestion/add', component: AddMcqQuestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/mcqquestion/edit/:id', component: EditMcqQuestionComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/usermanagement', component: UserManagementComponent, canActivate: [AdminAuthGuardService] },
      { path: 'adminpage/usermanagement/edit/:id', component: EditUserManagementComponent, canActivate: [AdminAuthGuardService] },
    ]),
  ],
  providers: [
    AdminAuthGuardService
  ],
})
export class AdminModule {

}
