using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Models
{
    public class Utils
    {
        public static List<Employee> Populate()
        {
            List<Employee> list = new List<Employee>();

            //list.Add(new Employee(101,"Narendra Modi", "Ahmdabad", 3_50_000.00));

            list.Add(new Employee(101, "Narendra Modi", "Ahmedabad", 350000.00));
            list.Add(new Employee(102, "Amit Shah", "Gandhinagar", 250000.00));
            list.Add(new Employee(103, "Rahul Gandhi", "New Delhi", 200000.00));
            list.Add(new Employee(104, "Sonia Gandhi", "New Delhi", 225000.00));
            list.Add(new Employee(105, "Arvind Kejriwal", "Delhi", 250000.00));
            list.Add(new Employee(106, "Yogi Adityanath", "Lucknow", 275000.00));
            list.Add(new Employee(107, "Mamata Banerjee", "Kolkata", 250000.00));
            list.Add(new Employee(108, "Naveen Patnaik", "Bhubaneswar", 200000.00));
            list.Add(new Employee(109, "Uddhav Thackeray", "Mumbai", 225000.00));
            list.Add(new Employee(110, "Pinarayi Vijayan", "Thiruvananthapuram", 250000.00));
            list.Add(new Employee(111, "Nitish Kumar", "Patna", 200000.00));
            list.Add(new Employee(112, "Shivraj Singh Chouhan", "Bhopal", 275000.00));
            list.Add(new Employee(113, "Sharad Pawar", "Mumbai", 225000.00));
            list.Add(new Employee(114, "Hemant Soren", "Ranchi", 250000.00));
            list.Add(new Employee(115, "K. Chandrashekar Rao", "Hyderabad", 200000.00));
            list.Add(new Employee(116, "Akhilesh Yadav", "Lucknow", 250000.00));
            list.Add(new Employee(117, "Shashi Tharoor", "Thiruvananthapuram", 225000.00));
            list.Add(new Employee(118, "Mayawati", "Lucknow", 275000.00));
            list.Add(new Employee(119, "Owaisi", "Hyderabad", 200000.00));
            list.Add(new Employee(120, "Sushil Kumar Modi", "Patna", 225000.00));
            list.Add(new Employee(121, "Jyotiraditya Scindia", "Gwalior", 250000.00));
            list.Add(new Employee(122, "Manohar Lal Khattar", "Chandigarh", 200000.00));
            list.Add(new Employee(123, "Sarbananda Sonowal", "Guwahati", 275000.00));
            list.Add(new Employee(124, "N. Rangaswamy", "Puducherry", 225000.00));
            list.Add(new Employee(125, "Biplab Kumar Deb", "Agartala", 250000.00));

            list.Add(new Employee(151, "Kumar Sanu", "Kolkata", 950000.00));
            list.Add(new Employee(152, "Udit Narayan", "Mumbai", 925000.00));
            list.Add(new Employee(153, "Alka Yagnik", "Mumbai", 900000.00));
            list.Add(new Employee(154, "Anu Malik", "Mumbai", 875000.00));
            list.Add(new Employee(155, "Nadeem-Shravan", "Mumbai", 850000.00));
            list.Add(new Employee(156, "A. R. Rahman", "Chennai", 825000.00));
            list.Add(new Employee(157, "Jatin-Lalit", "Mumbai", 800000.00));
            list.Add(new Employee(158, "Kavita Krishnamurthy", "Mumbai", 775000.00));
            list.Add(new Employee(159, "Sonu Nigam", "Mumbai", 750000.00));
            list.Add(new Employee(160, "S. P. Balasubrahmanyam", "Chennai", 725000.00));
            list.Add(new Employee(161, "Kumar Shanu & Alka Yagnik", "Mumbai", 700000.00));
            list.Add(new Employee(162, "Abhijeet Bhattacharya", "Mumbai", 675000.00));
            list.Add(new Employee(163, "Hariharan", "Mumbai", 650000.00));
            list.Add(new Employee(164, "Kumar Sanu & Sadhana Sargam", "Mumbai", 625000.00));
            list.Add(new Employee(165, "Usha Uthup", "Kolkata", 600000.00));
            list.Add(new Employee(166, "Suresh Wadkar", "Mumbai", 575000.00));
            list.Add(new Employee(167, "Lata Mangeshkar", "Mumbai", 550000.00));
            list.Add(new Employee(168, "Asha Bhosle", "Mumbai", 525000.00));
            list.Add(new Employee(169, "Kishore Kumar", "Mumbai", 500000.00));
            list.Add(new Employee(170, "Mohammed Rafi", "Mumbai", 475000.00));
            list.Add(new Employee(171, "R. D. Burman", "Mumbai", 450000.00));
            list.Add(new Employee(172, "Bappi Lahiri", "Mumbai", 425000.00));
            list.Add(new Employee(173, "Amit Kumar", "Mumbai", 400000.00));
            list.Add(new Employee(174, "Asha Bhosle & Kishore Kumar", "Mumbai", 375000.00));
            list.Add(new Employee(175, "Usha Uthup & Bappi Lahiri", "Mumbai", 350000.00));

            list.Add(new Employee(201, "Amitabh Bachchan", "Mumbai", 34500000.50));
            list.Add(new Employee(202, "Shah Rukh Khan", "Mumbai", 32200000.75));
            list.Add(new Employee(203, "Salman Khan", "Mumbai", 29600000.80));
            list.Add(new Employee(204, "Akshay Kumar", "Mumbai", 28250000.00));
            list.Add(new Employee(205, "Aamir Khan", "Mumbai", 26500000.25));
            list.Add(new Employee(206, "Hrithik Roshan", "Mumbai", 24200000.90));
            list.Add(new Employee(207, "Ajay Devgn", "Mumbai", 23250000.00));
            list.Add(new Employee(208, "Ranveer Singh", "Mumbai", 21000000.50));
            list.Add(new Employee(209, "Varun Dhawan", "Mumbai", 19500000.25));
            list.Add(new Employee(210, "Ranbir Kapoor", "Mumbai", 18250000.75));
            list.Add(new Employee(211, "Shahid Kapoor", "Mumbai", 17200000.90));
            list.Add(new Employee(212, "Saif Ali Khan", "Mumbai", 16500000.25));
            list.Add(new Employee(213, "John Abraham", "Mumbai", 15750000.00));
            list.Add(new Employee(214, "Farhan Akhtar", "Mumbai", 14500000.50));
            list.Add(new Employee(215, "Vicky Kaushal", "Mumbai", 13250000.75));
            list.Add(new Employee(216, "Tiger Shroff", "Mumbai", 12500000.80));
            list.Add(new Employee(217, "Kartik Aaryan", "Mumbai", 11700000.00));
            list.Add(new Employee(218, "Siddharth Malhotra", "Mumbai", 10550000.25));
            list.Add(new Employee(219, "Ayushmann Khurrana", "Mumbai", 9950000.50));
            list.Add(new Employee(220, "Rajkummar Rao", "Mumbai", 9325000.25));
            list.Add(new Employee(221, "Arjun Kapoor", "Mumbai", 8750000.75));
            list.Add(new Employee(222, "Sushant Singh Rajput", "Mumbai", 8150000.90));
            list.Add(new Employee(223, "Karan Johar", "Mumbai", 7750000.25));
            list.Add(new Employee(224, "Sanjay Leela Bhansali", "Mumbai", 7400000.00));
            list.Add(new Employee(225, "Anurag Kashyap", "Mumbai", 6900000.50));

            list.Add(new Employee(251, "Vikram Chandra", "Mumbai", 3_00_000.00)); // NDTV
            list.Add(new Employee(252, "Sundar Pichai", "Mountain View", 2_60_000.00)); // Google
            list.Add(new Employee(253, "Indra Nooyi", "Purchase", 2_50_000.00)); // PepsiCo
            list.Add(new Employee(254, "Mark Parker", "Beaverton", 3_00_000.00)); // Nike
            list.Add(new Employee(255, "Ramon Laguarta", "Purchase", 2_40_000.00)); // PepsiCo
            list.Add(new Employee(256, "James Quincey", "Atlanta", 2_75_000.00)); // Coca-Cola
            list.Add(new Employee(257, "Doug McMillon", "Bentonville", 2_50_000.00)); // Walmart
            list.Add(new Employee(258, "Satya Nadella", "Redmond", 2_50_000.00)); // Microsoft
            list.Add(new Employee(259, "Ginni Rometty", "Armonk", 2_30_000.00)); // IBM
            list.Add(new Employee(260, "Brian Chesky", "San Francisco", 2_80_000.00)); // Airbnb
            list.Add(new Employee(261, "Reed Hastings", "Los Gatos", 2_90_000.00)); // Netflix
            list.Add(new Employee(262, "Ajaypal Singh Banga", "New York", 2_50_000.00)); // Mastercard
            list.Add(new Employee(263, "Satoshi Tsunakawa", "Tokyo", 2_25_000.00)); // Toshiba Corporation
            list.Add(new Employee(264, "Sundararajan P", "Chennai", 1_80_000.00)); // Wipro
            list.Add(new Employee(265, "Arvind Krishna", "New York", 2_40_000.00)); // IBM
            list.Add(new Employee(266, "Mary T. Barra", "Detroit", 2_90_000.00)); // General Motors
            list.Add(new Employee(267, "Daniel Zhang", "Hangzhou", 3_50_000.00)); // Alibaba Group
            list.Add(new Employee(268, "Francisco D'Souza", "New Jersey", 2_00_000.00)); // Cognizant
            list.Add(new Employee(269, "Jeff Bezos", "Seattle", 3_50_000.00)); // Amazon
            list.Add(new Employee(270, "Satya Narayanan R", "Bangalore", 1_50_000.00)); // Infosys
            list.Add(new Employee(271, "Robert A. Iger", "Brentwood", 3_00_000.00)); // Walt Disney
            list.Add(new Employee(272, "Jes Staley", "London", 2_75_000.00)); // Barclays
            list.Add(new Employee(273, "Masayoshi Son", "Tokyo", 4_50_000.00)); // SoftBank Group
            list.Add(new Employee(274, "Trevor Noah", "New York", 2_20_000.00)); // The Daily Show
            list.Add(new Employee(275, "Tim Cook", "Cupertino", 2_75_000.00));

            Console.WriteLine(list.Count);

            return list;
        }


    }
}
