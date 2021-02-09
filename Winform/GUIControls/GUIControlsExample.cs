using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Utility;
using WinformExamples.GUIControls.Model;

namespace WinformExamples.GUIControls
{
	public partial class GUIControlsExample : Form
	{
		private SortOrder currentResultSortOrder;
		private SortableBindingList<Student> studentsViewModel;

		public GUIControlsExample()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
		}

		private void DgvStudentList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			int dataIndex = e.RowIndex;
			Object value = dgvStudentList.Rows[dataIndex].Cells[e.ColumnIndex].Value;

			Student student = studentsViewModel[dataIndex];

			Console.WriteLine($"Changed student : {student.ToString()}");
		}

		private void DgvStudentList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0) return;

			if ((int)dgvStudentList.Rows[e.RowIndex].Cells["NumberInClass"].Value > 10)
			{
				dgvStudentList.Rows[e.RowIndex].Cells["Name"].Style.BackColor = Color.Yellow;
			}
		}

		private void DgvStudentList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == dgvStudentList.Columns["BirthDate"].Index) return;

			SortOrder so = SortOrder.None;
			if (currentResultSortOrder == SortOrder.None ||
				currentResultSortOrder == SortOrder.Ascending)
			{
				so = SortOrder.Descending;
			}
			else
			{
				so = SortOrder.Ascending;
			}

			if (so == SortOrder.Ascending)
			{
				studentsViewModel.Sort(Student.CompareByName);
			}
			else
			{
				studentsViewModel.Sort(Student.CompareByNameDescending);
			}

			currentResultSortOrder = so;
		}

		private List<Student> GetSelectedStudents()
		{
			List<Student> selectedStudent = new List<Student>();

			DataGridViewSelectedRowCollection selectedRows = dgvStudentList.SelectedRows;

			foreach (DataGridViewRow seledteRow in selectedRows)
			{
				Student student = seledteRow.DataBoundItem as Student;

				if (student != null) selectedStudent.Add(student);
			}

			return selectedStudent;
		}

		private void GUIControlsExample_Load(object sender, EventArgs e)
		{
			studentsViewModel = new SortableBindingList<Student>();
			dgvStudentList.Columns.Clear();
			dgvStudentList.DataSource = studentsViewModel;
			School school = new School()
			{
				Name = "Korea Hightschool",
				Address = "Seoul"
			};

			Class classInfo = new Class(school)
			{
				ClassNumber = 5,
				Location = "Second floor",
			};

			for (int i = 0; i < 20; i++)
			{
				studentsViewModel.Add(new Student(classInfo)
				{
					NumberInClass = i + 1,
					Name = $"{i + 1}_Ben",
					BirthDate = DateTime.Now,
				});
			}

			SetGridDefaultStyle();
			ShowHideColumns();

			RegisterEvents();
		}

		private void HideAllColumns()
		{
			for (int i = 0; i < dgvStudentList.Columns.Count; i++)
			{
				dgvStudentList.Columns[i].Visible = false;
			}
		}

		private void RegisterEvents()
		{
			dgvStudentList.CellEndEdit += DgvStudentList_CellEndEdit;
			dgvStudentList.CellPainting += DgvStudentList_CellPainting;
			dgvStudentList.ColumnHeaderMouseClick += DgvStudentList_ColumnHeaderMouseClick;
		}

		private void SetGridDefaultStyle()
		{
			dgvStudentList.ReadOnly = false;
			dgvStudentList.EnableHeadersVisualStyles = false;
			dgvStudentList.AllowUserToResizeRows = false;
			dgvStudentList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvStudentList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			dgvStudentList.AllowUserToAddRows = false;
			dgvStudentList.BackgroundColor = Color.FromArgb(50, 50, 50);

			dgvStudentList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvStudentList.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
			dgvStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
			dgvStudentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			dgvStudentList.ColumnHeadersHeight = 30;
			dgvStudentList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

			dgvStudentList.RowTemplate.Height = 30;
		}

		private void ShowColumn(int displayIndex, string columnName, string headerText, bool isReadOnly = true, int columnWidth = 100, bool isAutoSize = false)
		{
			dgvStudentList.Columns[columnName].DisplayIndex = displayIndex;
			dgvStudentList.Columns[columnName].Visible = true;
			dgvStudentList.Columns[columnName].Width = columnWidth;
			dgvStudentList.Columns[columnName].HeaderText = headerText;
			dgvStudentList.Columns[columnName].ReadOnly = isReadOnly;

			if (isAutoSize)
			{
				dgvStudentList.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}

			if (dgvStudentList.Columns[columnName] is DataGridViewImageColumn)
			{
				((DataGridViewImageColumn)dgvStudentList.Columns[columnName]).DefaultCellStyle.Padding = new Padding(0, 5, 0, 5);
				((DataGridViewImageColumn)dgvStudentList.Columns[columnName]).ImageLayout = DataGridViewImageCellLayout.Zoom;
			}
		}

		private void ShowHideColumns()
		{
			HideAllColumns();

			Student student = new Student(null);

			ShowColumn(0, nameof(student.NumberInClass), "번호", false, 70);
			ShowColumn(1, nameof(student.Name), "이름", false, 100);
			ShowColumn(2, nameof(student.BirthDate), "생년월일", true, 150);
			ShowColumn(3, nameof(student.classInfo), "School and Class", true, 70, true);
		}

	}
}