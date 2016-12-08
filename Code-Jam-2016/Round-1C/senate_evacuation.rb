def solve(senators)
  if total(senators) < 1
    ""
  else
    max_index = senators.index(senators.max)
    senators[max_index] -= 1
    unless is_majority(senators)
      "(#{max_index}) #{solve(senators)}"
    else
      max_index2 = senators.index(senators.max)
      senators[max_index2] -= 1
      unless is_majority(senators)
        "(#{max_index})(#{max_index2}) #{solve(senators)}"
      else
        "broken"
      end
    end
  end
end

def total(senators)
  total = 0
  senators.each { |s| total += s }
  total
end

def is_majority(senators)
  total = total(senators)
  total == 1 || senators.any? { |s| s > total / 2 }
end

def covert(map, string)
  (0..25).reverse_each do |i|
    string.gsub!("#{i}", map[i])
  end
  string.gsub!('(', '').gsub!(')', '')
end

map = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')

i = 1
(1..number_of_cases).each do |case_number|
	senators = stream[i + 1].chomp.split(' ').map(&:to_i)
  result =  solve(senators)
  # hint = result.dup
  i += 2
	out_file.puts "Case ##{case_number}: #{covert(map, result)}"
  # out_file.puts "Case ##{case_number}: #{hint} : #{covert(map, result)}"

end

# result =  solve("188 201 179 19 19 17 19 17 15 15 25 13 17 22 15 24 20 27 11 27 19 17 14 22 21 17".split(' ').map(&:to_i))
# puts result
# puts covert(map, result)
#
# result =  solve([2,2])
# puts covert(map, result)
#
# result =  solve([3,2,2])
# puts covert(map, result)
#
# result =  solve([1,1,2])
# puts covert(map, result)
#
# result =  solve([2,3,1])
# puts covert(map, result)
#puts solve([0,1,1])
