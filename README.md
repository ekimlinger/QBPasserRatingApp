# QBPasserRating


## Description: Create a console application that calculates quarterback rating.
### User Input: The user will need to input the following items:
1. Player name
2. Passes attempted
3. Passes completed
4. Passing yards
5. Number of touchdown passes
6. Number of interceptions

### Output: Once the QB rating is calculated, display the rating in the following format:
PLAYER NAME’s QB Rating is: RATING
Where PLAYER NAME is the name the user input and RATING is the one you calculated
Calculating Quarterback Rating: To calculate quarterback rating, there are 4 measurements that are used:
1. Weighted value of percentage of completions per attempt
2. Weighted value of average yards gained per attempt
3. Weighted value of percentage of touchdown passes per attempt
4. Weighted value of percentage of interceptions per attempt

### Weighted Value of Percentage of Completions per Attempt: 
To calculate the percentage of completions per attempt, take the number of completions divided by the number of attempts and multiply by 100. Take the resulting value and subtract 30, then multiply by 0.05. If this value is less than 0, award 0 points. If the value is greater than 2.375, award 2.375 points.

### Weighted Value of Average Yards Gained Per Attempt: 
To calculate the average yards gained per attempt, take the number of passing yards and divide by the number of attempts. Subtract 3 from this value, then multiply by 0.25. If the result is less than 0, award 0 points. If the result is greater than 2.375, award 2.375 points.

### Weighted Value of Percentage of Touchdown Passes: 
Take the total number of touchdown passes and divide by the number of attempts and multiply by 100. Multiply this result by 0.2. If the result is greater than 2.375, award 2.375 points.

### Weighted Value of Interceptions: 
Take the total number of interceptions and divide by the number of attempts and multiply by 100. Multiply the result by 0.25 and then subtract this value from 2.375. If the value is less than 0, award 0 points.

## Final calculation: Sum the four values calculated in the above steps. Divide the sum by 6 and then multiply by 100.

### Example Calculation: Here is an example of calculating QB rating

#### User Input:
1. Player Name: Steve Young
2. Pass Attempts: 461
3. Pass Completions: 324
4. Passing Yards: 3969
5. Passing Touchdowns: 35
6. Interceptions: 10

#### Weighted Completion Percentage:
1. 324/461*100 = 70.28
2. 70.28 – 30 = 40.28
3. 40.28 * 0.05 = 2.014

#### Weighted Yards Per Attempt:
1. 3969/461 = 8.61
2. 8.61 – 3 = 5.61
3. 5.61 * 0.25 = 1.403

#### Weighted Percentage of Touchdown Passes:
1. 35/461*100 = 7.59
2. 7.59 * 0.2 = 1.518

#### Weighted Percentage of Interceptions:
1. 10/461*100 = 2.17
2. 2.17 * 0.25 = 0.542
3. 2.375 – 0.542 = 1.833

#### Final Calculation:
1. 2.014 + 1.403 + 1.518 + 1.833 = 6.768
2. 6.768/6 = 1.128
3. 1.128 * 100 = 112.8

## Quarterback rating is always shown as a decimal with 1 decimal place.
## The maximum value in any of the 4 calculations is 2.375
## The player must have at least 1 pass attempt
### Note that the values in the example were rounded for ease of reading, you do not need to round the individual calculations, just the final QB rating.
