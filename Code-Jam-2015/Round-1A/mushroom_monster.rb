def solve (mushrooms)
  diffs = get_differences(mushrooms)
  one = solve_method_one(diffs)
  two = solve_method_two(mushrooms, diffs)
  [one, two]
end

def get_differences(mushrooms)
  diffs =  [];
  (1...mushrooms.length).each do |i|
    diffs.push(mushrooms[i] - mushrooms[i-1])
  end
  diffs
end

def solve_method_one(diffs)
  total = 0;
  diffs.each do |diff|
    total -= diff unless diff > 0
  end
  total
end

def solve_method_two(mushrooms, diffs)
  max_negative = diffs.min
  unless max_negative > 0
    max_negative = diffs.min * -1
    total = 0
    mushrooms[0...mushrooms.length - 1].each do |mushroom|
      unless mushroom < max_negative
        total += max_negative
      else
        total += mushroom
      end
    end
    total
  else
    0
  end
end

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	mushrooms = stream[case_number * 2].chomp.split(' ').map(&:to_i)
	one, two = solve(mushrooms)
	out_file.puts "Case ##{case_number}: #{one} #{two}"
end

# puts solve([10,5,15,5])
# puts solve([100,100])
# puts solve([81, 81, 81, 81, 81, 81, 81, 0])
# puts solve([23, 90, 40, 0, 100, 9])
