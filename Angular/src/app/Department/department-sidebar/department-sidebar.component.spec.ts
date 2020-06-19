import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentSidebarComponent } from './department-sidebar.component';

describe('DepartmentSidebarComponent', () => {
  let component: DepartmentSidebarComponent;
  let fixture: ComponentFixture<DepartmentSidebarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentSidebarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
