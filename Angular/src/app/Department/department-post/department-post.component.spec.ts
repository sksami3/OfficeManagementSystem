import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentPostComponent } from './department-post.component';

describe('DepartmentPostComponent', () => {
  let component: DepartmentPostComponent;
  let fixture: ComponentFixture<DepartmentPostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentPostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
