import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './customers.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CustomersComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path: "", component: CustomersComponent } //Customera istek geldiğinde şu komponente git.
    ])
  ]
})
export class CustomersModule { }
