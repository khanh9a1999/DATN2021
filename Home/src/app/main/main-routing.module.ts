
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { DetailComponent } from './detail/detail.component';
import { TypeComponent } from './type/type.component';
import { SearchComponent} from './search/search.component'
const routes: Routes = [
    //đây là file link của home module
  {path:'',component:MainComponent},//link là localhost:4200/home 
  { path:'detail/:id',component: DetailComponent},//link là localhost:4200/home/details
  { path:'type/:id',component: TypeComponent},
  { path:'search',component: SearchComponent},
];

@NgModule({
    imports: [CommonModule,RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class MainRoutingModule { }