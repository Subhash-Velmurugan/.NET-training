// 1. Find the area of a triangle with sides 5, 6, 7
function calculateTriangleArea() {
    var a = 5;
    var b = 6;
    var c = 7;

    var s = (a + b + c) / 2;
    var area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

    console.log("Triangle Area:", area);
}

// 2. Print star pattern using nested for loop
function printStarPattern() {
    for (var i = 1; i <= 5; i++) {
        var pattern = "";
        for (var j = 1; j <= i; j++) {
            pattern += "* ";
        }
        console.log(pattern);
    }
}

// 3. Check whether a given year is a leap year
function checkLeapYear(year) {
    if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
        console.log(year + " is a Leap Year");
    } else {
        console.log(year + " is NOT a Leap Year");
    }
}

// 4. Calculate days left until Independence Day (August 15)
function daysUntilIndependenceDay() {
    var today = new Date();
    var currentYear = today.getFullYear();

    var independenceDay = new Date(currentYear, 7, 15); // August = 7

    if (today > independenceDay) {
        independenceDay = new Date(currentYear + 1, 7, 15);
    }

    var oneDay = 24 * 60 * 60 * 1000;
    var daysLeft = Math.ceil((independenceDay - today) / oneDay);

    console.log("Days left until Independence Day:", daysLeft);
}

/* ---- Function Calls ---- */
calculateTriangleArea();
printStarPattern();
checkLeapYear(2024);
daysUntilIndependenceDay();