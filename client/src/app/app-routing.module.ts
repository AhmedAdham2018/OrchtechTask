import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewClassComponent } from './add-new-class/add-new-class.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: '' , component: HomeComponent},
  {path: 'add-new-class' , component: AddNewClassComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
