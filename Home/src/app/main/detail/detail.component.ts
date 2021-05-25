import { Component,Injector,OnInit } from '@angular/core';
import { BaseComponent } from '../../Services/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { takeUntil } from 'rxjs/operators';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent extends BaseComponent implements OnInit {

  ct:any;
  tuongtu:any;
  constructor(injector : Injector) { 
    super(injector);
   }

  ngOnInit(): void {
    this.ct = {};
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/bangtin/get-by-id/'+id).pipe(takeUntil(this.unsubscribe)).subscribe((res: any) => {
        this.ct = res;
        setTimeout(() => {
          this.loadScripts();
        });
      }); 
    });
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/bangtin/get-tuongtu/'+id).takeUntil(this.unsubscribe).subscribe(res => {
        this.tuongtu = res;
      })
    })
  }

}
