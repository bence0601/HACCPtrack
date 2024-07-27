import React from "react";
import { View, Text, StyleSheet, Image } from "react-native";

const ProfileHeader = ({ userName }) => {
  const currentDate = new Date().toLocaleDateString("hu-HU", {
    day: "2-digit",
    month: "long",
    year: "numeric",
  });

  return (
    <View style={styles.container}>
      <Image
        style={styles.profilePic}
        source={{
          uri: "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png",
        }}
      />
      <View>
        <Text style={styles.greeting}>Hi, {userName}</Text>
        <Text style={styles.date}>{currentDate}</Text>
      </View>
      <View style={styles.notificationIcon}>{/* Notification Icon */}</View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    padding: 16,
  },
  profilePic: {
    width: 40,
    height: 40,
    borderRadius: 20,
  },
  greeting: {
    fontSize: 18,
    fontWeight: "bold",
  },
  date: {
    fontSize: 14,
    color: "gray",
  },
  notificationIcon: {
    // styles for notification icon
  },
});

export default ProfileHeader;
