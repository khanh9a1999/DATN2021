import { Component, Injector,OnInit } from '@angular/core';
import { BaseComponent } from '../Services/base-component'
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  bantins : any;
  theloai : any ;
  public pageSize = 3;
  public page = 1;
  public totalRecords:any;
  public formsearch: any;
  public formdata: any;
  submitted = false;
  constructor(private fb: FormBuilder,injector : Injector) { 
    super(injector);
   }
  ngOnInit(): void {
    this.formsearch = this.fb.group({
      'tieude': [''],
    });
    this._api.get('api/theloai/get-category').takeUntil(this.unsubscribe).subscribe(res => {this.theloai = res;});
    this.search();
  }
  search() { 
    this.page = 1;
    this.pageSize = 5;
    this._api.post('/api/bangtin/search-bantin',{page: this.page, pageSize: this.pageSize, tieude: this.formsearch.get('tieude').value}).takeUntil(this.unsubscribe).subscribe(res => {
      this.bantins = res.data;
      this.totalRecords =  res.totalItems;
      this.pageSize = res.pageSize;
      });
  }

}
