import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailComponent } from './detail/detail.component';
import { MainComponent } from './main.component';
import { MainRoutingModule } from './main-routing.module';
import { TypeComponent } from './type/type.component';
import { SearchComponent } from './search/search.component';

@NgModule({
    declarations: [
        MainComponent,
        DetailComponent,
        TypeComponent,
        SearchComponent,

    ],
    imports: [
      CommonModule,
      MainRoutingModule
    ]
  })
  export class MainModule { }