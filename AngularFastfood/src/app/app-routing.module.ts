import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestingComponent } from './Components/testing/testing.component';
import { ProductviewComponent } from './Components/productview/productview.component';

const routes: Routes = [
  {path: 'home', component: TestingComponent},
  {path: 'products', component: ProductviewComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
