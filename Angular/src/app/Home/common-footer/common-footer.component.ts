import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'common-footer',
  templateUrl: './common-footer.component.html',
  styleUrls: ['./common-footer.component.css']
})
export class CommonFooterComponent implements OnInit {

  endDivtag: Array<string> = ['</div>', '</div>'];
  text: string;

  result: any;
  html = this.sanitized.bypassSecurityTrustHtml("</div>");

  constructor(private sanitized: DomSanitizer) { 
    
  }

  ngOnInit(): void {
    this.result = this.sanitized.bypassSecurityTrustHtml(this.text);
  }

}
