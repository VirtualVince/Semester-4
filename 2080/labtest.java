// Vincente Sequeira
// 4/29/2020
// 101484793
// COMP 2080
// Lab Test

public class labtest {
    public class Employee {
        public String employeeCode;
        public String name;
        public String position;
        public String phone;
        public int officeNum;

        public Employee(String employeeCode, String name, String position, String phone, int officeNum) {
            this.employeeCode = employeeCode;
            this.name = name;
            this.position = position;
            this.phone = phone;
            this.officeNum = officeNum;
        }
    }

    public class OrderedObjects {
        private Employee[] employees;
        private int count;
        private static final int MAX_EMPLOYEES = 200;

        public OrderedObjects() {
            employees = new Employee[MAX_EMPLOYEES];
            count = 0;
        }

        public boolean addObject(String employeeCode, String name, String position, String phone, int officeNum) {
            if (count >= MAX_EMPLOYEES) {
                return false;
            }

            if (employeeExists(name)) {
                return false;
            }

            Employee newEmployee = new Employee(employeeCode, name, position, phone, officeNum);
            employees[count] = newEmployee;
            count++;

            selectionSort();

            return true;
        }

        private void selectionSort() {
            for (int i = 0; i < count - 1; i++) {
                int minIndex = i;
                for (int j = i + 1; j < count; j++) {
                    if (employees[j].name.compareToIgnoreCase(employees[minIndex].name) < 0) {
                        minIndex = j;
                    }
                }

                Employee temp = employees[i];
                employees[i] = employees[minIndex];
                employees[minIndex] = temp;
            }
        }

        private int binarySearch(String name) {
            int low = 0;
            int high = count - 1;

            while (low <= high) {
                int mid = (low + high) / 2;
                int comparison = employees[mid].name.compareToIgnoreCase(name);

                if (comparison == 0) {
                    return mid;
                } else if (comparison < 0) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }

            return -1;
        }

        public boolean employeeExists(String name) {
            return binarySearch(name) != -1;
        }
    }
}