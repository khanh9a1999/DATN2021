import { Component, OnInit,Injector } from '@angular/core';
import { BaseComponent } from '../../Services/base-component';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent extends BaseComponent implements OnInit {

  public pageSize = 3;
  public page = 1;
  public formsearch: any;
  bantins :any;
  totalRecords : any;
  constructor(injector : Injector) {
    super(injector);
   }

  ngOnInit(): void {
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
