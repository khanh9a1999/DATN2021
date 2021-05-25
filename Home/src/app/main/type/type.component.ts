import { Component,Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../Services/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
@Component({
  selector: 'app-type',
  templateUrl: './type.component.html',
  styleUrls: ['./type.component.css']
})
export class TypeComponent extends BaseComponent implements OnInit {

  btoftype:any;
  page: any;
  pageSize: any;
  totalItems:any;
  idtheloai:any;
  constructor(injector : Injector) { 
    super(injector);
   }

  ngOnInit(): void {
    this.btoftype = [];
    this.page = 1;
    this.pageSize = 8;
    this._route.params.subscribe(params => {
      this.idtheloai = params['id'];
      this._api.post('api/bangtin/search-category', { 
        page: this.page, 
        pageSize: this.pageSize, 
        idtheloai: this.idtheloai}).takeUntil(this.unsubscribe).subscribe(res => {
        this.btoftype = res.data;
        this.totalItems = res.totalItems;
        }, err => { }); 
        });
  }

}
